using System;
using System.Collections.Generic;
using System.Linq;
using Assessments.Mapping.Models.Source.Species;

namespace Assessments.Mapping.Helpers
{
    static public class CategoryAndCriteriaHelper
    {
        static public string[] allcriterias = new string[] { "", "NA", "NE", "LC", "DD", "NT", "VU", "EN", "CR", "RE", "EW", "EX" };

        static public string HandleEmptyValues(string value)
        {
            return (value == null || value == "-") ? "" : value;
        }
        static public string ChopCategorystring(string s)
        {
            return s.Substring(0, Math.Min(2, s.Length));
        }

        static public int CriteriaValue(string kriterie)
        {
            return Array.FindIndex(allcriterias, x => x == HandleEmptyValues(kriterie));
        }

        static public string GetCriteria(int criteriaValue)
        {
            return allcriterias[criteriaValue];
        }

        static public string Condstring(bool truethy, string str)
        {
            return truethy ? "" + str : "";
        }
        static public string Condstring(string truethy, string str)
        {
            return !string.IsNullOrEmpty(truethy) ? "" + str : "";
        }

        static public string CombineStrings(IEnumerable<string> arr, string sep)
        {
            var s = sep == null ? "," : sep;
            var items = arr.Where(item => !string.IsNullOrWhiteSpace(item));
            var result = string.Join(s, items);
            return result;
        }

        static public string Wrapstring(string pre, string str, string post)
        {
            //var p = post ?? "";
            var result = Condstring(str, "" + pre + str + post);
            return result;
        }
        static public string Wrapstring(string pre, IEnumerable<string> strs, string post, string sep)
        {
            var p = post ?? "";
            var str = CombineStrings(strs, sep);
            var result = Condstring(str, "" + pre + str + p);
            return result;
        }

        static public int HighestKategoriValue(IEnumerable<CategoryAndCriteria> katkrits)
        {
            var result = katkrits.Select(x => CriteriaValue(x.Kategori)).DefaultIfEmpty(0).Max();
            return result;
        }
        static public int RomanNumber(string roman)
        {
            // for this purpose this is enough
            var romans = new string[] { "i", "ii", "iii", "iv", "v", "vi", "vii", "viii", "ix", "x" };
            var result = Array.IndexOf<string>(romans, roman);
            return result;
        }
        static public int CompareRomanNumbers(string a, string b)
        {
            var aval = RomanNumber(a);
            var bval = RomanNumber(b);
            return aval < bval ? -1 : aval == bval ? 0 : 1;
        }
        static public CategoryAndCriteria limitKategory(CategoryAndCriteria katkrit, int max)
        {
            //let maxlevel = typeof(max) === 'string' ? criteriaValue(max) : typeof(max) === 'number' ? max : criteriaValue(max.kategori)
            var maxlevel = max;
            var kriterialevel = CriteriaValue(katkrit.Kategori);
            var newlevel = kriterialevel > maxlevel ? maxlevel : kriterialevel;
            var newKat = GetCriteria(newlevel);
            var newkatkrit = new CategoryAndCriteria(newKat, katkrit.Allebruktekriterier, katkrit.Kriterie);
            return newkatkrit;
        }
        static public CategoryAndCriteria limitKategory(CategoryAndCriteria katkrit, string max)
        {
            return limitKategory(katkrit, CriteriaValue(max));
        }
        static public CategoryAndCriteria limitKategory(CategoryAndCriteria katkrit, CategoryAndCriteria max)
        {
            return limitKategory(katkrit, max.Kategori);
        }

        //string combineKrits(IEnumerable<string> krits)  
        //{
        //                combined = wrapstring(pre, krits, p, sep)
        //            return combined
        //}

        static public CategoryAndCriteria combineKatKrits(IEnumerable<CategoryAndCriteria> katkrits, string pre, string post, string sep)
        { // apply formating (using wrapstring) while combining katkrits
            int highestValue = HighestKategoriValue(katkrits);
            if (highestValue <= 0)
            {
                return new CategoryAndCriteria();
            }
            string kat = GetCriteria(highestValue);
            //kk = katkrits.filter(item => !!item.kategori)  // propably not necessary...
            var ukk = katkrits.Where(item => highestValue == CriteriaValue(item.Kategori)); // utslagsgivende
            var utslagsgivende = Wrapstring(pre, ukk.Select(kk => kk.Kriterie), post, sep);
            var alle = Wrapstring(pre, katkrits.Select(kk => kk.Allebruktekriterier), post, sep);
            var result = new CategoryAndCriteria(kat, alle, utslagsgivende);
            return result;
        }
        // --------------------------------------------------------------------
        static public int mainordinal(string kat)
        {
            int result =
                kat == "CR" ? 0 :
                kat == "EN" ? 1 :
                kat == "VU" ? 2 :
                3;
            return result;
        }

        static public bool hasValue(string s)
        {
            return !(string.IsNullOrWhiteSpace(s) || s == "-");
        }

        static public string[] baijaTroligborctable = new string[] { "VU", "VU", "NT", "LC" };
        static public string baijaTroligborc(string borc)
        {
            return baijaTroligborctable[mainordinal(borc)];
        }

        static public string[][] baiitable = new string[][] {
            new string[] {"NT", "NT", "LC", "LC" },
            new string[] {"NT", "NT", "LC", "LC" },
            new string[] {"LC", "LC", "LC", "LC" },
            new string[] {"LC", "LC", "LC", "LC" }
        };
        static public string baii(string mainkat, string aii)
        {
            return baiitable[mainordinal(aii)][mainordinal(mainkat)];
        }

        static public string[][] baiibOrctable = new string[][] {
            new string[] { "CR", "EN", "VU", "NT" },
            new string[] { "EN", "EN", "VU", "NT" },
            new string[] { "VU", "VU", "VU", "NT" },
            new string[] { "NT", "NT", "NT", "NT" }
        };
        static public string baiibOrc(string mainkat, string aii)
        {
            return baiibOrctable[mainordinal(aii)][mainordinal(mainkat)];
        }

        static public string[][][] baijaTroligaiiborctable = new string[][][] {
            new string[][] { new string[] { "CR", "(ii)"     }, new string[] { "EN", "(ii)"     }, new string[] { "VU", "(ii)"     }, new string[] { "NT", "(ii)" } },
            new string[][] { new string[] { "EN", "(ii)"     }, new string[] { "EN", "(ii)"     }, new string[] { "VU", "(ii)"     }, new string[] { "NT", "(ii)" } },
            new string[][] { new string[] { "VU", "((i),ii)" }, new string[] { "VU", "((i),ii)" }, new string[] { "VU", "(ii)"     }, new string[] { "NT", "(ii)" } },
            new string[][] { new string[] { "VU", "((i))"    }, new string[] { "VU", "((i))"    }, new string[] { "NT", "((i),ii)" }, new string[] { "NT", "(ii)" } }
        };
        static public string[] baijaTroligaiiborc(string mainkat, string aii)
        {
            return baijaTroligaiiborctable[mainordinal(aii)][mainordinal(mainkat)];
        }

        static public string[][] c1table = new string[][] {
            new string[] { "CR", "EN", "VU", "NT" },
            new string[] { "EN", "EN", "VU", "NT" },
            new string[] { "VU", "VU", "VU", "NT" },
            new string[] { "NT", "NT", "NT", "LC" }
        };
        static public int c1ordinal(string kat)
        {
            return kat == "25" ? 0 : kat == "20" ? 1 : kat == "10" ? 2 : 3;
        }
        static public string c1kat(string mainkat, string value)
        {
            return hasValue(mainkat) && hasValue(value) ?
            c1table[c1ordinal(value)][mainordinal(mainkat)] :
            "";
        }

        static public string[][] c2aitable = new string[][] {
            new string[] { "CR", "EN", "VU", "NT" },
            new string[] { "EN", "EN", "VU", "NT" },
            new string[] { "VU", "VU", "VU", "NT" }
        };
        static public int c2aiordinal(string kat)
        {
            return kat == "50" ? 0 : kat == "250" ? 1 : 2;
        }
        static public string c2aikat(string mainkat, string value)
        {
            return hasValue(mainkat) && hasValue(value) ?
            c2aitable[c2aiordinal(value)][mainordinal(mainkat)] :
            "";
        }

        static public string[][] c2aiitable = new string[][] {
            new string[] { "CR", "LC", "LC", "LC" },
            new string[] { "CR", "EN", "LC", "LC" },
            new string[] { "CR", "EN", "VU", "NT" }
        };
        static public int c2aiiordinal(string kat)
        {
            return kat == "90" ? 0 : kat == "95" ? 1 : 2;
        }
        static public string c2aiikat(string mainkat, string value)
        {
            return hasValue(mainkat) && hasValue(value) ?
            c2aiitable[c2aiiordinal(value)][mainordinal(mainkat)] :
            "";
        }

        // ----------- A --------------
        static public CategoryAndCriteria akrit(string pre, string kat, IEnumerable<string> krit)
        {
            return
                !string.IsNullOrWhiteSpace(kat) && krit.Count() > 0 ?
                new CategoryAndCriteria(kat, Wrapstring(pre + "(", krit, ")", ",")) :
                new CategoryAndCriteria();
        }
        static public CategoryAndCriteria oppsummeringA(Rodliste2019 model)
        {

            var a1 = akrit("1", model.A1OpphørtOgReversibel, model.A1EndringBasertpåKode.OrderBy(x => x));
            var a2 = akrit("2", model.A2Forutgående10År, model.A2EndringBasertpåKode.OrderBy(x => x));
            var a3 = akrit("3", model.A3Kommende10År, model.A3EndringBasertpåKode.OrderBy(x => x));
            var a4 = akrit("4", model.A4Intervall10År, model.A4EndringBasertpåKode.OrderBy(x => x));
            var a = combineKatKrits(new CategoryAndCriteria[] { a1, a2, a3, a4 }, "A", "", "+");
            return a;
        }
        // ----------- B --------------
        static public CategoryAndCriteria bTilleggskriterier(string mainKat, string kriterieName, Rodliste2019 model)
        {
            if (mainKat == null)
            {
                return new CategoryAndCriteria();
            }
            int toNum(string krit) => string.IsNullOrEmpty(krit) ? 0 : 1;
            bool crOrEn(string kat) => CriteriaValue(kat) >= CriteriaValue("EN");
            bool ntOrVu(string kat) => kat == "NT" || kat == "VU";
            string aiVerdi = HandleEmptyValues(model.BA1KraftigFragmenteringKode);
            string aiiKategori = HandleEmptyValues(model.BA2FåLokaliteterKode);
            IEnumerable<string> bKriterier = model.BBPågåendeArealreduksjonKode.OrderBy(x => RomanNumber(x));
            IEnumerable<string> cKriterier = model.BCEksterneFluktuasjonerKode.OrderBy(x => RomanNumber(x));
            //-----
            string downToNtOrLc = crOrEn(mainKat) ? "NT" : "LC";
            string aiKode = aiVerdi == "ja" ? "i" : aiVerdi == "jaTrolig" ? "(i)" : "";
            string aiAdjustedKat = aiVerdi == "ja" ? mainKat : aiVerdi == "jaTrolig" ? crOrEn(mainKat) ? "VU" : mainKat == "VU" ? "NT" : mainKat == "NT" ? "LC" : mainKat : "";
            int aiiLevel = CriteriaValue(aiiKategori);
            string aiiAdjustedKat = aiiLevel > 0 ? GetCriteria(Math.Min(CriteriaValue(mainKat), aiiLevel)) : mainKat;
            bool aiiAdjustedKatIsLower(string kat) => CriteriaValue(aiiAdjustedKat) < CriteriaValue(kat);
            string aiAndaiiAdjustetdKat = GetCriteria(Math.Max(CriteriaValue(aiAdjustedKat), CriteriaValue(aiiAdjustedKat)));
            string aiiKode = !string.IsNullOrEmpty(aiiKategori) ? "ii" : "";
            string aKode(bool excludeaii, bool excludeai) =>
                            excludeaii && excludeai ? "" :
                            excludeaii ? Wrapstring("a(", aiKode, ")") :
                            excludeai ? !string.IsNullOrEmpty(aiiKode) ? Wrapstring("a(", aiiKode, ")") : "" :
                            Wrapstring("a(", new List<string> { aiKode, aiiKode }, ")", ",");
            string bKode = Wrapstring("b(", bKriterier, ")", ",");
            string cKode = Wrapstring("c(", cKriterier, ")", ",");
            string abcKode(bool excludeaii, bool excludeai) => "" + aKode(excludeaii, excludeai) + bKode + cKode;
            int aibcCount = toNum(aiKode) + toNum(bKode) + toNum(cKode);
            int bcCount = toNum(bKode) + toNum(cKode);
            CategoryAndCriteria result1 = bcCount == 0 && aiVerdi == "ja" && !string.IsNullOrEmpty(aiiKategori) && crOrEn(mainKat) && crOrEn(aiiKategori) ? // ai + aii 
                                new CategoryAndCriteria("NT", kriterieName + "a(i,ii)") :
                                bcCount == 0 && aiVerdi == "jaTrolig" && !string.IsNullOrEmpty(aiiKategori) && crOrEn(mainKat) && aiiKategori == "VU" ? // a(i) + aii (NT or VU) 
                                new CategoryAndCriteria("LC", kriterieName + "a((i),ii)") :
                                bcCount == 0 && aiVerdi == "ja" ? // kun a(i) (and possible a(ii) )
                                new CategoryAndCriteria(downToNtOrLc, kriterieName + abcKode(false, false), kriterieName + abcKode(true, false)) :
                                bcCount == 0 && aiVerdi == "jaTrolig" && string.IsNullOrEmpty(aiiKategori) ? // kun a((i))
                                new CategoryAndCriteria("LC", kriterieName + abcKode(false, false), kriterieName + abcKode(true, false)) :
                                bcCount == 0 && aiVerdi != "ja" && !string.IsNullOrEmpty(aiiKategori) ? //  kun a(ii) {+ evt a((i)) }
                                new CategoryAndCriteria(baii(mainKat, aiiKategori), kriterieName + abcKode(false, false), kriterieName + abcKode(false, true)) :
                                bcCount == 1 && aiVerdi == "ja" && !string.IsNullOrEmpty(aiiKategori) ? // a(i) + a(ii) + et bc
                                new CategoryAndCriteria(aiAndaiiAdjustetdKat, kriterieName + abcKode(false, false), kriterieName + abcKode(aiiAdjustedKatIsLower(aiAndaiiAdjustetdKat), false)) :
                                bcCount == 1 && aiVerdi == "jaTrolig" && string.IsNullOrEmpty(aiiKategori) ? // to underkriterier, men et av disse er a((i))
                                new CategoryAndCriteria(baijaTroligborc(mainKat), kriterieName + abcKode(false, false), kriterieName + abcKode(true, false)) :
                                bcCount == 1 && aiVerdi == "jaTrolig" && !string.IsNullOrEmpty(aiiKategori) ? // to underkriterier, men et av disse er a((i)) + a(ii)
                                new CategoryAndCriteria(baijaTroligaiiborc(mainKat, aiiKategori)[0], kriterieName + abcKode(false, false), kriterieName + "a" + baijaTroligaiiborc(mainKat, aiiKategori)[1] + bKode + cKode) :
                                bcCount == 1 && !string.IsNullOrEmpty(aiiKode) ? // to underkriterier, men et er aii
                                new CategoryAndCriteria(baiibOrc(mainKat, aiiKategori), kriterieName + abcKode(false, false)) :
                                bcCount == 2 && aiVerdi == "jaTrolig" ? // b+c og a(i)
                                new CategoryAndCriteria(mainKat, kriterieName + abcKode(false, false), kriterieName + abcKode(aiiAdjustedKatIsLower(mainKat), true)) :
                                aibcCount >= 2 ? // minst to sikre underkriterier
                                new CategoryAndCriteria(mainKat, kriterieName + abcKode(false, false), kriterieName + abcKode(aiiAdjustedKatIsLower(mainKat), false)) :
                                aibcCount == 1 && crOrEn(mainKat) ? // minst EN med ett sikkert underkriterie
                                new CategoryAndCriteria("NT", kriterieName + abcKode(false, false), kriterieName + abcKode(true, false)) :
                                aibcCount == 1 && ntOrVu(mainKat) ? // minst EN med ett sikkert underkriterie
                                new CategoryAndCriteria("LC", kriterieName + abcKode(false, false), kriterieName + abcKode(true, false)) :
                                !string.IsNullOrEmpty(aiiKode) && crOrEn(mainKat) && crOrEn(aiiKategori) ? // minst EN og aii er minst EN
                                new CategoryAndCriteria("NT", kriterieName + abcKode(false, false)) :
                                new CategoryAndCriteria(),
                        result2 = result1.Kategori == "LC" ? new CategoryAndCriteria("LC", result1.Allebruktekriterier, "") : result1;
            return result2;
        }

        static public CategoryAndCriteria oppsummeringB(Rodliste2019 model)
        {
            CategoryAndCriteria b1 = bTilleggskriterier(HandleEmptyValues(model.B1UtbredelsesområdeKode), "1", model);
            CategoryAndCriteria b2 = bTilleggskriterier(HandleEmptyValues(model.B2ForekomstarealKode), "2", model);
            CategoryAndCriteria b = combineKatKrits(new List<CategoryAndCriteria> { b1, b2 }, "B", "", "+");
            return b;
        }
        // ----------- C --------------
        static public CategoryAndCriteria oppsummeringC(Rodliste2019 model)
        {
            var c = new CategoryAndCriteria(model.CPopulasjonsstørrelseKode, "C");
            var cLevel = CriteriaValue(c.Kategori);
            var c1 = new CategoryAndCriteria(c1kat(c.Kategori, model.C1PågåendePopulasjonsreduksjonKode), "1");
            var c2ai = new CategoryAndCriteria(c2aikat(c.Kategori, model.C2A1PågåendePopulasjonsreduksjonKode), "i");
            var c2aii = new CategoryAndCriteria(c2aiikat(c.Kategori, model.C2A2PågåendePopulasjonsreduksjonKode), "ii");
            var c2bCat = model.C2BPågåendePopulasjonsreduksjonKode == "JA" ? model.CPopulasjonsstørrelseKode : "";
            var c2b = new CategoryAndCriteria(c2bCat, "b");
            var c2a = combineKatKrits(new List<CategoryAndCriteria> { c2ai, c2aii }, "a(", ")", ",");
            var c2 = combineKatKrits(new List<CategoryAndCriteria> { c2a, c2b }, "2", "", "");
            var cTillegskriterier = combineKatKrits(new List<CategoryAndCriteria> { c1, c2 }, "", "", "+");
            var cTillegskriterierLevel = CriteriaValue(cTillegskriterier.Kategori);
            var cTotal = (cLevel == 0 || cTillegskriterierLevel == 0) ?
                        new CategoryAndCriteria() :
                        combineKatKrits(new List<CategoryAndCriteria> { limitKategory(c, cTillegskriterier), cTillegskriterier }, "", "", "");
            return cTotal;
        }

        // ----------- D --------------
        static public CategoryAndCriteria oppsummeringD(Rodliste2019 model)
        {
            var d1 = new CategoryAndCriteria(model.D1FåReproduserendeIndividKode, "1");
            var d2 = new CategoryAndCriteria(model.D2MegetBegrensetForekomstarealKode, "2");
            var d = combineKatKrits(new List<CategoryAndCriteria> { d1, d2 }, "D", "", "+");
            return d;
        }
        // ----------- E --------------
        static public CategoryAndCriteria oppsummeringE(Rodliste2019 model)
        {
            var e = new CategoryAndCriteria(model.EKvantitativUtryddingsmodellKode, "E");
            return e;
        }
        // ----------- Total --------------
        static public CategoryAndCriteria oppsummeringTotal(Rodliste2019 model)
        {
            var total = combineKatKrits(new List<CategoryAndCriteria> { oppsummeringA(model), oppsummeringB(model), oppsummeringC(model), oppsummeringD(model), oppsummeringE(model) }, "", "", "; ");
            var overordnetKlassifisering = model.OverordnetKlassifiseringGruppeKode;
            var katEndretTil = model.KategoriEndretTil;
            if (model.UtdøingSterktPåvirket == "Ja" && !string.IsNullOrEmpty(katEndretTil))
            {
                total.KategoriEndretFra = total.Kategori;
                total.Kategori = katEndretTil;
            }
            if (overordnetKlassifisering != "rodlisteVurdertArt")
            {
                if (string.IsNullOrWhiteSpace(overordnetKlassifisering))
                {
                    Console.WriteLine("mangler overordnetKlassifisering");
                }

                //Console.WriteLine("klassifisering: " + overordnetKlassifisering);
                total.Kategori = overordnetKlassifisering.Substring(overordnetKlassifisering.Length - 2);
                total.Kriterie = "";
            }
            return total;
        }
        // ----------- Set oppsummening total --------------
        static public void setOppsummeringTotal(Rodliste2019 model)
        {
            model.OppsummeringAKriterier = oppsummeringA(model).Kriterie;
            model.OppsummeringBKriterier = oppsummeringB(model).Kriterie;
            model.OppsummeringCKriterier = oppsummeringC(model).Kriterie;
            model.OppsummeringDKriterier = oppsummeringD(model).Kriterie;
            model.OppsummeringEKriterier = oppsummeringE(model).Kriterie;
            var total = oppsummeringTotal(model);
            model.Kriterier = total.Kriterie;
            model.Kategori = total.Kategori;
        }
    }
}